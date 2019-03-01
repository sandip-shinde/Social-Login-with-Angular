
class LocalStorageService {

    getItem(key){
        return window.localStorage.getItem(key);        
    }

    setItem(key, value){
        window.localStorage.setItem(key, value);
    }
}

export let storageService = new LocalStorageService();