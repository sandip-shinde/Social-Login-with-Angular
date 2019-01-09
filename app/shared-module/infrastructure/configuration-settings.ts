﻿import {
    Environment
} from '../../environments/environment';

export let ConfigurationSettings = {
    defaultRoutePrefix: "",
    numberOfApiRetryAttempt: 3,
    LogLevel: 3, // 0-OFF , 1-ERROR , 2-WARN, 3-INFO, 4-DEBUG, 5-LOG
    supportedBrowserLanguages: ["en", "en-us", "en-gb", "fr"],
    fallbackBrowserLanguage: "en"
};