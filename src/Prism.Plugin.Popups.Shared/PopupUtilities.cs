﻿using System;
using System.Linq;
using Prism.Common;
using Prism.Navigation;
using Prism.Plugin.Popups.Extensions;
using Rg.Plugins.Popup.Contracts;
using Xamarin.Forms;

namespace Prism.Plugin.Popups
{
    internal static class PopupUtilities
    {
        public static NavigationParameters CreateNewNavigationParameters() =>
            new NavigationParameters()
            {
                { KnownNavigationParameters.NavigationMode, NavigationMode.New }
            };

        public static NavigationParameters CreateBackNavigationParameters() =>
            new NavigationParameters()
            {
                { KnownNavigationParameters.NavigationMode, NavigationMode.Back }
            };

        public static Page TopPage(IPopupNavigation popupNavigation, IApplicationProvider applicationProvider)
        {
            Page page = null;
            if(popupNavigation.PopupStack.Count > 0)
                page = popupNavigation.PopupStack.LastOrDefault();
            else if(applicationProvider.MainPage.Navigation.ModalStack.Count > 0)
                page = applicationProvider.MainPage.Navigation.ModalStack.LastOrDefault();
            else
                page = applicationProvider.MainPage.Navigation.NavigationStack.LastOrDefault();

            if(page == null)
                page = applicationProvider.MainPage;

            return page.GetDisplayedPage();
        }

        public static Page GetOnNavigatedToTarget(IPopupNavigation popupNavigation, IApplicationProvider applicationProvider)
        {
            Page page = null;
            if(popupNavigation.PopupStack.Count > 1)
                page = popupNavigation.PopupStack.ElementAt(popupNavigation.PopupStack.Count() - 2);
            else if(applicationProvider.MainPage.Navigation.ModalStack.Count > 0)
                page = applicationProvider.MainPage.Navigation.ModalStack.LastOrDefault();
            else
                page = applicationProvider.MainPage.Navigation.NavigationStack.LastOrDefault();

            if(page == null)
                page = applicationProvider.MainPage;

            return page.GetDisplayedPage();
        }
    }
}
