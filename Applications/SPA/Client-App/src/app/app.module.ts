import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
// Component
import { AppComponent } from './app.component';
import { LoginComponent } from './feature/login/login.component';

// Service
import { AuthHttpService } from './share/services/auth-http.service';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    AuthHttpService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
