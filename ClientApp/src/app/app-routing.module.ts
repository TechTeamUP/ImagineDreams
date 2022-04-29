import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./components/pages/home/home.component";
import { AboutComponent } from './components/pages/about/about.component';
import { SearchComponent } from './components/pages/search/search.component';
import { ItemDetailsComponent } from './components/pages/item-details/item-details.component';
import { AuthGuard } from "./security/auth.guard";



const app_routes: Routes = [
    {path: 'home', component: HomeComponent},
    {path: 'about', component: AboutComponent, canActivate: [AuthGuard]},
    {path: 'item/:id', component: ItemDetailsComponent},
    {path: 'search/:term', component: SearchComponent, canActivate: [AuthGuard]},
    {path: '**', pathMatch: 'full', redirectTo: 'home'}
];

@NgModule({
    imports:[
        RouterModule.forRoot(app_routes, {useHash: true})
    ],
    exports:[
        RouterModule
    ],

})

export class AppRoutingModule{}