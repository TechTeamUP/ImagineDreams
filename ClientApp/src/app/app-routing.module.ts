import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./components/pages/home/home.component";
import { AboutComponent } from './components/pages/about/about.component';
import { SearchComponent } from './components/pages/search/search.component';
import { ItemDetailsComponent } from './components/pages/item-details/item-details.component';
import { ImagesComponent } from "./images/images.component";
import { ImageListComponent } from "./images/image-list/image-list.component";



const app_routes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'about', component: AboutComponent },
    { path: 'item/:id', component: ItemDetailsComponent },
    { path: 'search/:term', component: SearchComponent },
    { path: '**', pathMatch: 'full', redirectTo: 'home' },
    { path: '', redirectTo: 'image/upload', pathMatch: 'full' },
    {
        path: 'image', component: ImagesComponent, children: [
            { path: 'upload', component: ImagesComponent },
            { path: 'lsit', component: ImageListComponent }
        ]
    }
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