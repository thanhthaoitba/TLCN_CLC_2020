import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {HomeComponent} from '../app/home/home.component';
import {CommingSoon} from '../app/commingsoon/commingsoon.component';
import {Err404} from '../app/Err404/Err404.component'
import {bloglist} from '../app/bloglist/bloglist.component'
import {movielist} from '../app/movielist/movielist.component'
import {moviesingle} from '../app/moviesingle/moviesingle.component'
import {celebritylist} from '../app/celebritylist/celebritylist.component'
import {celebritypeople} from '../app/celebritypeople/celebritypeople.component'
import {userrate} from '../app/userrate/userrate.component'
import {userprofile} from '../app/userprofile/userprofile.component'
import {userfavoritieslist} from '../app/userfavoritieslist/userfavoritieslist.component'
import {blogdetail} from '../app/blogdetail/blogdetail.component'

const routes: Routes = [
  { path: 'home',             component: HomeComponent },
  { path: 'comming',             component: CommingSoon },
  { path: 'Error',             component: Err404 },
  { path: 'Bloglist',             component: bloglist },
  { path: 'MovieList',             component: movielist },
  { path: 'MovieSingle',             component: moviesingle },
  { path: 'FamousList',             component: celebritylist },
  { path: 'FamousPeople',             component: celebritypeople },
  { path: 'UserRate',             component: userrate },
  { path: 'UserProfile',             component: userprofile },
  { path: 'UserFlim',             component: userfavoritieslist },
  { path: 'BlogDetail',             component: blogdetail },
  { path: '**', redirectTo: '/home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
