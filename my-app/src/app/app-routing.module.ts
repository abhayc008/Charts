import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HeroesComponent }      from './heroes/heroes.component';
import { DashboardComponent }   from './dashboard/dashboard.component';
import { HeroDetailComponent }  from './hero-detail/hero-detail.component';
import { MyDashboardComponent } from './my-dashboard/my-dashboard.component';
import { MynvaComponent } from './mynva/mynva.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
{ path: '', redirectTo: '/dashboard', pathMatch: 'full' },
{ path: 'dashboard', component: DashboardComponent },
{ path: 'detail/:id', component: HeroDetailComponent },
{ path: 'heroes', component: HeroesComponent },
{ path:'login', component:LoginComponent},
{ path:'MyDashboard', component:MyDashboardComponent},
{ path:'nav' , component: MynvaComponent}
];

@NgModule({
	imports: [ RouterModule.forRoot(routes) ],
	exports: [ RouterModule ]
})
export class AppRoutingModule {}