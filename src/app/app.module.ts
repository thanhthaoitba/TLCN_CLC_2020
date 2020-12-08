import { BrowserModule } from '@angular/platform-browser'
import { NgModule } from '@angular/core'
import { HttpClientModule } from '@angular/common/http'

import { HomeComponent } from '../app/home/home.component'
import { CommingSoon } from '../app/commingsoon/commingsoon.component'
import { Err404 } from '../app/Err404/Err404.component'
import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component'
import { bloglist } from '../app/bloglist/bloglist.component'
import { movielist } from '../app/movielist/movielist.component'
import { moviesingle } from '../app/moviesingle/moviesingle.component'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { celebritylist } from '../app/celebritylist/celebritylist.component'
import { celebritypeople } from '../app/celebritypeople/celebritypeople.component'
import { APP_BASE_HREF } from '@angular/common'
import { HeaderComponent } from '../app/layout/header/header.component'
import { FooterComponent } from '../app/layout/footer/footer.component'
import { userrate } from '../app/userrate/userrate.component'
import { userprofile } from '../app/userprofile/userprofile.component'
import { userfavoritieslist } from '../app/userfavoritieslist/userfavoritieslist.component'
import { blogdetail } from '../app/blogdetail/blogdetail.component'




@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CommingSoon,
    Err404,
    bloglist,
    movielist,
    moviesingle,
    celebritylist,
    celebritypeople,
    HeaderComponent,
    FooterComponent,
    userrate,
    userprofile,
    userfavoritieslist,
    blogdetail,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
  ],
  providers: [{ provide: APP_BASE_HREF, useValue: '/' }],
  bootstrap: [AppComponent]
})
export class AppModule { }
