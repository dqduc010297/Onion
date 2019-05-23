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
import { LayoutComponent } from './layout/layout.component';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { NavigationComponent } from './layout/navigation/navigation.component';
import { TestcomponentComponent } from './feature/testcomponent/testcomponent.component';
import { PriceQuoteComponent } from './feature/price-quote/price-quote.component';
import { GridItemComponent } from './feature/price-quote/grid-item/grid-item.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    LayoutComponent,
    HeaderComponent,
    FooterComponent,
    NavigationComponent,
    TestcomponentComponent,
    PriceQuoteComponent,
    GridItemComponent,
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
