import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./components/pages/home/home.component";
import { AboutComponent } from './components/pages/about/about.component';



const app_routes: Routes = [
    {path: 'home', component: HomeComponent},
    {path: 'about', component: AboutComponent},
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