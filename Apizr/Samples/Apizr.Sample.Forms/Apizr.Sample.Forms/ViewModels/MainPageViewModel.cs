﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Apizr.Configuring.Registry;
using Apizr.Extending.Configuring.Registry;
using Apizr.Optional.Cruding;
using Apizr.Optional.Cruding.Sending;
using Apizr.Requesting;
using Apizr.Sample.Models;
using Fusillade;
using MediatR;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Shiny;
using Color = System.Drawing.Color;

namespace Apizr.Sample.Forms.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        private readonly IApizrManager<IReqResService> _reqResManager;
        private readonly IApizrManager<IHttpBinService> _httpBinManager;
        private readonly IApizrManager<ICrudApi<User, int, PagedResult<User>, IDictionary<string, object>>> _userCrudManager;
        private readonly IApizrManager<ICrudApi<UserDetails, int, IEnumerable<UserDetails>, IDictionary<string, object>>> _userDetailsCrudManager;
        private readonly IMediator _mediator;
        private readonly IApizrCrudOptionalMediator<User, int, PagedResult<User>, IDictionary<string, object>> _userOptionalMediator;

        public MainPageViewModel(IApizrExtendedRegistry apizrRegistry)
            //IApizrManager<IReqResService> reqResManager),
            //IApizrManager<ICrudApi<User, int, PagedResult<User>, IDictionary<string, object>>> userCrudManager,
            //IApizrManager<IHttpBinService> httpBinManager,
            //IApizrManager<ICrudApi<UserDetails, int, IEnumerable<UserDetails>, IDictionary<string, object>>> userDetailsCrudManager,
            //IMediator mediator,
            //ICrudOptionalMediator<User, int, PagedResult<User>, IDictionary<string, object>> userOptionalMediator)
        {
            _reqResManager = apizrRegistry.GetManagerFor<IReqResService>(); //reqResManager;
            _userCrudManager = apizrRegistry.GetCrudManagerFor<User, int, PagedResult<User>, IDictionary<string, object>>(); //userCrudManager;
            _httpBinManager = apizrRegistry.GetManagerFor<IHttpBinService>(); //httpBinManager;
            //_userDetailsCrudManager = userDetailsCrudManager;
            //_mediator = mediator;
            //_userOptionalMediator = userOptionalMediator;
            GetUsersCommand = ReactiveCommand.CreateFromTask(GetUsersAsync);
            GetUserDetailsCommand = ReactiveCommand.CreateFromTask<User>(GetUserDetailsAsync);
            AuthCommand = ReactiveCommand.CreateFromTask(AuthAsync);
            Users = new ObservableList<User>();

            Title = "Main Page";
        }

        #region Properties

        [Reactive] public ObservableList<User> Users { get; set; }

        [Reactive] public bool IsRefreshing { get; set; }

        public ICommand GetUsersCommand { get; }

        public ICommand GetUserDetailsCommand { get; }

        public ICommand AuthCommand { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Managing crud entities comes with many web api call flavors
        /// Choosing one of it depends of your registration settings
        /// and how you like to play with api calls
        /// </summary>
        /// <returns></returns>
        private async Task GetUsersAsync()
        {
            if (IsRefreshing)
                return;

            IsRefreshing = true;

            IList<User>? users = null;
            try
            {
                // This is a manually defined web api call into IReqResService (classic actually)
                var userList = await _reqResManager.ExecuteAsync(api => api.GetUsersAsync());
                users = userList?.Data;

                //var userList2 = await _reqResManager.ExecuteAsync(api => api.GetUsersAsync((int)Priority.UserInitiated));

                //var userList3 = await _reqResManager.ExecuteAsync(api => api.GetUsersAsync((int)Priority.Background));

                // This is the Crud way, with or without Crud attribute auto registration, but without mediation
                //var pagedUsers = await _userCrudManager.ExecuteAsync((ct, api) => api.ReadAll((int)Priority.UserInitiated, ct), CancellationToken.None);
                //users = pagedUsers?.Data?.ToList();

                // The same as before but with auto mediation handling
                //var pagedUsers = await _mediator.Send(new ReadAllQuery<PagedResult<User>>(), CancellationToken.None);
                //users = pagedUsers?.Data?.ToList();
            }
            catch (ApizrException<UserList> e)
            {
                var message = e.InnerException is IOException ? "No network" : (e.Message ?? "Error");
                UserDialogs.Instance.Toast(new ToastConfig(message) { BackgroundColor = Color.Red, MessageTextColor = Color.White });

                users = e.CachedResult?.Data;
            }
            catch (ApizrException<PagedResult<User>> e)
            {
                var message = e.InnerException is IOException ? "No network" : (e.Message ?? "Error");
                UserDialogs.Instance.Toast(new ToastConfig(message) { BackgroundColor = Color.Red, MessageTextColor = Color.White });

                users = e.CachedResult?.Data?.ToList();
            }
            finally
            {
                if (users != null && users.Any())
                    Users.ReplaceAll(users);
                
                IsRefreshing = false;
            }

            // The same as before but with optional result
            //var result = await _mediator.Send(new ReadAllOptionalQuery<PagedResult<User>>(), CancellationToken.None);
            //result.Match(pagedUsers =>
            //{
            //    if (pagedUsers.Data != null && pagedUsers.Data.Any())
            //        Users = new ObservableCollection<User>(pagedUsers.Data);
            //}, e =>
            //{
            //    var message = e.InnerException is IOException ? "No network" : (e.Message ?? "Error");
            //    UserDialogs.Instance.Toast(new ToastConfig(message) { BackgroundColor = Color.Red, MessageTextColor = Color.White });

            //    if (e.CachedResult?.Data != null && e.CachedResult.Data.Any())
            //        Users = new ObservableCollection<User>(e.CachedResult.Data);
            //});

            // The same as before but with fluent result handling (fetched or cached, doesn't matter) and global exception handling (AsyncErrorHandler)
            //await _userOptionalMediator.SendReadAllOptionalQuery().OnResultAsync(pagedUsers =>
            //{
            //    if (!pagedUsers.Data.IsEmpty())
            //        Users = new ObservableCollection<User>(pagedUsers.Data);

            //    IsRefreshing = false;
            //});

            //var pagedUsers = await _userOptionalMediator.SendReadAllOptionalQuery().CatchAsync(AsyncErrorHandler.HandleException);
            //if (!pagedUsers.Data.IsEmpty())
            //    Users = new ObservableCollection<User>(pagedUsers.Data);
            
            //IsRefreshing = false;
        }

        /// <summary>
        /// Managing crud entities comes with 3 web api call flavors
        /// Choosing one of it depends of your registration settings
        /// and how you like to play with api calls.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task GetUserDetailsAsync(User user)
        {

            User? fetchedUser = null;

            try
            {
                // This is a manually defined web api call into IReqResService (classic actually)
                var userDetails = await _reqResManager.ExecuteAsync((ct, api) => api.GetUserAsync(user.Id, (int)Priority.UserInitiated, ct), CancellationToken.None);
                fetchedUser = userDetails?.User;

                // This is the Crud way, with or without Crud attribute auto registration, but without mediation
                //var userDetails = await _userDetailsCrudManager.ExecuteAsync((ct, api) => api.Read(user.Id, ct), CancellationToken.None);
                //fetchedUser = userDetails?.User;

                // The same as before but with auto mediation handling and without optional result this time
                //var userDetails = await _mediator.Send(new ReadQuery<UserDetails>(user.Id), CancellationToken.None);
                //fetchedUser = userDetails?.User;
            }
            catch (ApizrException<UserDetails> e)
            {
                var message = e.InnerException is IOException ? "No network" : (e.Message ?? "Error");
                UserDialogs.Instance.Toast(new ToastConfig(message)
                { BackgroundColor = Color.Red, MessageTextColor = Color.White });

                fetchedUser = e.CachedResult?.User;
            }

            // The same as before but with auto mediation handling and with optional result
            //var result = await _mediator.Send(new ReadOptionalQuery<UserDetails>(user.Id), CancellationToken.None);
            //result.Match(userDetails =>
            //{
            //    fetchedUser = userDetails?.User;
            //}, e =>
            //{
            //    var message = e.InnerException is IOException ? "No network" : (e.Message ?? "Error");
            //    UserDialogs.Instance.Toast(new ToastConfig(message) { BackgroundColor = Color.Red, MessageTextColor = Color.White });

            //    fetchedUser = e.CachedResult?.User;
            //});

            if (fetchedUser != null)
                UserDialogs.Instance.Alert(
                    $"{fetchedUser.FirstName} {fetchedUser.LastName}\n {fetchedUser.Email}", fetchedUser.FirstName);
        }

        private async Task AuthAsync()
        {
            string result;
            var succeed = false;
            try
            {
                var response = await _httpBinManager.ExecuteAsync(api => api.AuthBearerAsync());
                succeed = response.IsSuccessStatusCode;
                result = response.IsSuccessStatusCode ? "Authentication succeed :)" : "Authentication failed :(";
            }
            catch (ApizrException e)
            {
                result = e.InnerException is IOException ? "No network" : (e.Message ?? "Error");
            }

            if (!string.IsNullOrWhiteSpace(result))
                UserDialogs.Instance.Toast(new ToastConfig(result)
                    {BackgroundColor = succeed ? Color.Green : Color.Red, MessageTextColor = Color.White});
        }

        #endregion

        #region Lifecycle

        public override void OnAppearing()
        {
            base.OnAppearing();

            GetUsersCommand.Execute(null);
        }

        #endregion
    }
}
