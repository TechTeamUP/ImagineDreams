import { Injectable } from "@angular/core";
import { Router, CanActivate, ActivatedRouteSnapshot } from "@angular/router";
import { UserService } from "../services/user.service";


/* Con esto indicamos que no hay sesion activa */
@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {

    constructor(private router: Router, private _UserService: UserService){
    }

    canActivate(route: ActivatedRouteSnapshot) {
        const user = this._UserService.userData;
        if(user)
        {   
            return true;
        }
        this.router.navigate(['/home']);
        return false
    }
}