import { Constants } from './constants';
import { authService } from './auth.service';

class HttpService {

    createQuerystring(params){
        return Object.keys(params)
        .map(k => encodeURIComponent(k) + '=' + encodeURIComponent(params[k]))
        .join('&');
    }
    
    get(url, options) {
        options = options || {};
        options.headers = options.headers || {};
        options.headers[Constants.requestHeader.contentType] = Constants.contentType.json;
        options.headers[Constants.requestHeader.accept] = Constants.contentType.json;
        options.headers[Constants.requestHeader.credentials] = 'include';
        authService.setAuthHeaders(options.headers);

        if(options.params){
            url = url + '?' + this.createQuerystring(options.params);
            delete options.params;
        }

        return fetch(url, {
                headers : options.headers
            })
            .then(this.checkStatus)
            .then(this.parseJSON)
            .catch((error) => {            
                  //this.handleError(error);
             });
    }

    post(url, options) {
        options = options || {};
        options.headers = options.headers || {};
        options.headers[Constants.requestHeader.contentType] = Constants.contentType.json;
        options.headers[Constants.requestHeader.accept] = Constants.contentType.json;
        options.headers[Constants.requestHeader.credentials] = 'include';
        authService.setAuthHeaders(options.headers);

        return fetch(url, {
            method : 'POST',
            body : options.body,
            headers : options.headers
            })
            .then(this.checkStatus)
            .then(this.parseJSON)
            .catch((error) => {            
                  //this.handleError(error);
            });

    }

    checkStatus(response) {
        if (response.status >= 200 && response.status < 300) {
            return response;
        } else {
            var error = new Error(response.statusText)
            error.response = response;
            throw error;
        }
    }

    parseJSON(response) {
        return response.json()
    }

}

export let httpService = new HttpService();