export class TokenManager {
    
    static isLoggedIn() {
        return this.getToken() !== null;
    }
    
    static getToken() {
        return sessionStorage.getItem("token");
    }
    
    static setToken(token) {
        sessionStorage.setItem("token", token);
    }
    
    static getRequestHeader() {
        return { 'X-Access-Token': this.getToken() }
    }
}