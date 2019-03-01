
export class Constants { }

const apiUrl = process.env.REACT_APP_API_URL;

Constants.apiUrl = {
    login : apiUrl + '/user/login',
    logout : apiUrl + '/user/logout',
    getUserData : apiUrl + '/user/getUserData'
};

Constants.requestHeader = {
    authorization: 'Authorization',
    bearer: 'Bearer',
    accept: 'Accept',
    contentType: 'Content-Type',
    credentials : 'credentials'
};

Constants.contentType =
{
    json: "application/json",
    formUrlEncoded: "application/x-www-form-urlencoded",
    multiPart: "multipart/form-data"
};

Constants.localStorageKeys = {
    apiToken : 'apiToken',
    isLoggedIn : 'isLoggedIn',
    userId : 'userId'
};