import { environment } from '../../environments/environment';

export class Config {
   
    public static getControllerUrl(controllerName: string, actionName?: string) {
        debugger
        return this.getApiUrl() + '/' + controllerName + (actionName ? '/' + actionName : '');
    }
    public static getApiUrl() {
        return this.getServerUrl() + '';
    }
    public static getServerUrl() {
        return environment.production ? '' : 'https://localhost:44385';
    }
    // public static getFirebaseConfig() {
    //     return {
    //         // apiKey: "AIzaSyCnfQz6KDgzDeztSiSV3Y7k13D5h6tu9Ts",
    //         apiKey: "AIzaSyDhK39-ZBuptKm4OabOMehNNRYL7DXalgI",
    //         authDomain: "hrmis-38c28.firebaseapp.com",
    //         databaseURL: "https://hrmis-38c28.firebaseio.com",
    //         projectId: "hrmis-38c28",
    //         storageBucket: "",
    //         messagingSenderId: "356200191641"
    //     }
    // }
 
}