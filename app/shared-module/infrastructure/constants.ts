
import { ConfigurationSettings } from './configuration-settings';
import { Environment } from '../../environment';

export class Constants {

    static regExType = {
        numeric: /^\d+$/,
        alphanumeric: /^[a-zA-Z0-9]*$/,
        alphanumericWithSpace: /^[a-zA-Z0-9 ]*$/,
        alphanumWithSpecial1: /^[a-zA-Z0-9!"'#$%&( )*+,./:;=?@^_-]*$/,
        decimalPrecisionFour: /^([0-9]*([.]{1}[0-9]{0,4})?)$/,
        decimalPrecisionTwo: /^([0-9]*([.]{1}[0-9]{0,2})?)$/,
        negativedecimalPrecisionFour: /^(-?[0-9]*([.]{1}[0-9]{0,4})?)$/,

        alph1anum1: '^.*(?=.{7,})(?=.*[0-9])(?=.*[a-zA-Z]).*$',
        phoneKey: /^[a-zA-Z0-9( )-]*$/,
        email: /^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/
    }

    static checkoutRedirectToAction =
    {
        profilePage: 1,
        checkoutPage: 2,
        checkoutFunction: 3
    }
    
    static iCCartDeliveryMethod =
    {
        serverPostXml: 1,
        serverPostFormEncoded: 2,
        clientPostFormEncoded: 3,
        clientBase64Encoded: 4
    }

    static imageExtension =
    {
        jpeg: ".jpeg",
        jpg: ".jpg"
    }

    static headerConstant =
    {
        xpLogo: "xpTopRightLogo.png",
        maxTransactionCount: 99,
        maxTransactionToUpdate: 100,
        replaceableCount: "({0})"
    }

    static uiRoutes = {
        empty: '',
        default: ConfigurationSettings.defaultRoutePrefix,
        login: 'login',
        resetpassword: 'resetpassword',
        product: 'product',
        offer: 'offer',
        order: 'order',
        invoice: 'invoice'
    };

    static webApis = {
        logout: Environment.apiUrl + 'account/logout',
        getSharedData: Environment.apiUrl + 'account/getUserData'
    };

    static nonCatalogSearchCriteria = {
        startPage: 1,
        startPageSize: 6
    }

    static scrollSettings = {
        infiniteScrollDistance: 10,
        infiniteScrollThrottle: 500
    }
    
    static searchCriteria = {
        startPage: 1,
        startPageSize: 12,
        activePrice: "ActivePrice",
        sortOrderAscending: "Asc",
        sortOrderDescending: "Desc",
        relevance: "Relevance",
        emptyFacet: "empty",
        notSpecifiedValue: "Not Specified",
        itemDefaultValue: -1,
        preferredSupplier: "Preferred",
        supplier: "Supplier",
        manufacturer: "Manufacturer",
        contract: "Contract",
        preferred: "Preferred Supplier",
        facetFilter: "facetFilter",
        underPriceFacet: "Under ",
        abovePriceFacet: " and above",
        priceTo: " to ",
        onContract: " On Contract",
    }

    static userSearchCriteria = {
        startPage: 1,
        startPageSize: 10
    }    

    static attachmentValidation = {
        AttachmentSizeLimit: 5, //size in MB
        AttachemntLimitAtNoteLevel: 5,
        AttachmentInvalidExtensions: ".exe, .com, .bat, .pif, .application, .gadget, .msi, .msp, .scr, .hta, .cpl, .msc, .jar, .bat, .vb, .vbs, .vbe, .js, .jse, .ws, .wsf, .wsc, .wsh, .ps1, .ps1xml, .ps2, .ps2xml, .psc1, .psc2, .msh, .msh1, .msh2, .mshxml, .msh1xml, .msh2xml, .scf, .lnk, .inf, .reg, .docm, .dotm, .xlsm, .xltm, .xlam, .pptm, .potm, .ppam, .ppsm, .sldm",
        TotalAttachmentSizeAcrossAllExternalNotes: 15, //size in MB
        TotalAttachmentSizeAcrossAllInternalNotes: 15, //size in MB
        TotalAttachmentSizeAtRequisitionLevel: 30 //size in MB
    }

    static businessExceptions = {
        SessionExpired: "SessionExpired",
        SessionKilled: "SessionKilled",
        ErrorCode: "ErrorCode",
        IsIntegratedCart: "IsIntegratedCart",
        MessageCode: "MessageCode"
    }

    static queryString = {
        SessionExpired: "SessionExpired=true",
        SessionKilled: "SessionKilled=true",
        me: "?me"
    }

    static localStorageKeys = {
        isSystemMessageClosed: "isSystemMessageClosed",
        isSuppressNonCatalogItemEnabled: "isSuppressNonCatalogItemEnabled"
    }

    static splitChars = {
        comma: ","
    }

    static cookies =
    {
        sessionId: "SessionId"
    }

    static requestHeader =
    {
        contentType: "Content-Type"
    }

    static contentType =
    {
        json: "application/json; charset=utf-8"
    }

}