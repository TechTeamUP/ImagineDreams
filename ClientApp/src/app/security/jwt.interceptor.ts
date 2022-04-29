import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { UserService } from "../services/user.service";

@Injectable()
export class JwtInterceptor implements HttpInterceptor
{
    constructor(private _UserService  : UserService)
    {

    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>>
    {
        const user = this._UserService.userData;
        if(user)
        {
            req = req.clone({
                setHeaders: {
                    Authorization: `Beare ${user.token}`
                }
            });
        }
        return next.handle(req)
    }
}