import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './feature/login/login.component';
import { LayoutComponent } from './layout/layout.component';
import { TestcomponentComponent } from './feature/testcomponent/testcomponent.component';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: '', component: LayoutComponent, children: [
    {path: 'dashboard', component: TestcomponentComponent},
    {path: 'supplier', component: TestcomponentComponent},
    {path: 'product', component: TestcomponentComponent},
    {path: 'order', component: TestcomponentComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
