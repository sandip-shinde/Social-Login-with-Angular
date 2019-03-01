
import { Constants } from './constants';
import { storageService } from './local-storage.service';

export class ApiTokenModel {
    access_token;
    refresh_token;
    ".expires";
}

class AuthService {

    apiToken;
    userId;
    isLoggeIn;
    
    constructor(        
    ) {
        this.isLoggeIn = false;
        this.setCurrentSessionData();
    }
    
    login(response){
        storageService.setItem(Constants.localStorageKeys.isLoggedIn, "true");
        storageService.setItem(Constants.localStorageKeys.apiToken, JSON.stringify(response.apiToken));
        storageService.setItem(Constants.localStorageKeys.userId, response.userId);
    }

    setCurrentSessionData(){
        this.apiToken = JSON.parse(storageService.getItem(Constants.localStorageKeys.apiToken));
        this.userId = storageService.getItem(Constants.localStorageKeys.userId);

        if(this.apiToken && this.userId){
            this.isLoggeIn = storageService.getItem(Constants.localStorageKeys.isLoggedIn) === "true";
        }
    }

    getUserId(){
        return this.userId;
    }
    
    isUserLoggedIn() {
        return this.isLoggeIn;
    }
    
    setAuthHeaders(headers) {        
        if (this.apiToken) {
            headers[Constants.requestHeader.authorization] = `${Constants.requestHeader.bearer} ${this.apiToken.access_token}`;
        }        
    }
    
    logOut() {
        storageService.setItem(Constants.localStorageKeys.isLoggedIn, null);
        storageService.setItem(Constants.localStorageKeys.userId, null);
        storageService.setItem(Constants.localStorageKeys.apiToken, null);
        this.apiToken = null;
        this.userId = null;
        this.isUserLoggedIn = null;
    }

}

export let authService = new AuthService();