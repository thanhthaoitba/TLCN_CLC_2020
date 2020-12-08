import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root',
  })
  
export class ConfigService {
  // constructor(private http: HttpClient) { }
  constructor() { }

  // configUrl = 'assets/config.json';

    // getConfig() {
    //     return this.http.get(this.configUrl);
    // }

    getRequests(params: any) {
      const url = `/eAdmin/os/getAllListRequest`
      return this.postApi(url, params)
    }

    getApi(url: any, params: any = null): Promise<any>{
      return <Promise<any>>this.get(url, params)
    }
    postApi(url: any, body: any): Promise<any>{
        return <Promise<any>>this.post(url, body)
    }

    get( url: any, token = ""){
      // let l_token = getToken();
      let l_token = ""
      return new Promise(function (resolve, reject) {
        fetch(url, {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
            "Access-Control-Allow-Origin": "*",
            "x-access-token": l_token,
          },
          mode: "cors",
        })
          .then(function (response) {
            if (response.status == 200) {
              return response.json();
            } else {
              resolve([]);
            }
          })
          .then(function (response) {
            resolve(response);
          })
          .catch((err) => {
            reject([]);
          });
      });
    }
    post(url: any, param: any){
      let l_token = ""
      // let l_token = getToken();
      return new Promise(function (resolve, reject) {
        fetch(url, {
          method: "POST",
          headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
            "Access-Control-Allow-Origin": "*",
            "x-access-token": l_token,
          },
          body: JSON.stringify(param),
        })
          .then(function (response) {
            if (response.status == 200) {
              return response.json();
            } else if (response.status == 404) {
              return { statusCode: 404 };
            } else {
              return {};
            }
          })
          .then(function (response) {
            resolve(response);
          })
          .catch((err) => {
            reject({});
          });
      });
    }
}
