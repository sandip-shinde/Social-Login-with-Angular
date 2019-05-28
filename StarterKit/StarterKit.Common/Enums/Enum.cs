﻿using StarterKit.Common.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterKit.Common.Enums
{
    public enum UserType
    {
        SuperVisor = 1,  
    }

    public enum ClassNames
    {
        ViewModel = 1,
        Page = 2
    }

    public enum LocalizedResourceType
    {
        SENDOTP_BUTTONTEXT,
        REGISTEREDEMAIL_PLACEHOLDER,
        EMAILID_PLACEHOLDER,
        PASSWORD_PLACEHOLDER,
        SIGNIN_HINTTEXT,
        SIGNIN_BUTTONTEXT,
        MESSAGE_LOGINFAILED,
        MESSAGE_UNAUTHORIZED,
        MESSAGE_INTERNALSERVERERROR,
        MESSAGE_FETCHDATAERROR,
        MESSAGE_INTERNETCONNECTIONERROR,
        MESSAGE_SQLLITEERROR,
        MESSAGE_AUTHENTICATING_PROGRESS,
        MESSAGE_EVENTLIST_PROGRESS,
        MESSAGE_SEVALISTDATA_LOADING,
        MESSAGE_SETNEWPASSWORD_PROGRESS,
        MESSAGE_REGISTERATION_PROGRESS,
        MESSAGE_FORGOTPASSWORD_PROGRESS,
        MESSAGE_LANDINGDETAILPAGE_PROGRESS,
        MESSAGE_OTPVERIFY_PROGRESS,
        MESSAGE_ABOUTUS_PROGRESS,
        MESSAGE_CONTACTUS_PROGRESS,
        USER_ALREADY_EXISTS,
        REGISTRATION_FAILED,
        MESSAGE_LOADING,
        ADDREMINDER_BUTTONTEXT,
        SETREMINDER_BUTTONTEXT,
        VERIFYOTP_BUTTONTEXT,
        ANNOUNCE_BUTTONTEXT,
        ADDALBUMTITLE,
        EDITALBUMTITLE,
        INVALIDOTPERROR,
        LOGOUTTITLE,
        LOGOUTMESSAGE,
        LOGOUTOK,
        LOGOUTCANCEL
    }

    public enum MenuItemsEnum
    {
        MENUITEM_MANAGEGALLERY = 0,
        MENUITEM_MANAGEANNOUNCEMENT,

        MENUITEM_CALENDAR,
        MENUITEM_SEVA,
        MENUITEM_GALLERY,
        MENUITEM_ABOUTUS,

        MENUITEM_CONTACTUS,
        MENUITEM_ABOUTAPP,
        MENUITEM_LOGOUT
    }

    public enum MenuItemsIcon
    {

        MENUITEMICON_MANAGEGALLERY = 0,
        MENUITEMICON_MANAGEANNOUNCEMENT,

        MENUITEMICON_CALENDAR,
        MENUITEMICON_SEVA,
        MENUITEMICON_GALLERY,
        MENUITEMICON_ABOUTUS,

        MENUITEMICON_CONTACTUS,
        MENUITEMICON_ABOUTAPP,
        MENUITEMICON_LOGOUT
    }

    public enum MenuItemsNavigation
    {
        MENUITEMSNAVIGATION_MANAGEGALLERY = 0,
        MENUITEMSNAVIGATION_MANAGEANNOUNCEMENT,

        MENUITEMSNAVIGATION_CALENDAR,
        MENUITEMSNAVIGATION_SEVA,
        MENUITEMSNAVIGATION_GALLERY,
        MENUITEMSNAVIGATION_ABOUTUS,

        MENUITEMSNAVIGATION_CONTACTUS,
        MENUITEMSNAVIGATION_ABOUTAPP,
        MENUITEMSNAVIGATION_LOGOUT
    }

    public enum APIEndPoints
    {
            [StringValue("user/getbyname")]
            Authenticate
    }
}
