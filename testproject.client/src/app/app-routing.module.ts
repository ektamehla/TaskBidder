import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeJobComponent } from './components/home-job/home-job.component';
import { CreateJobComponent } from './components/create-job/create-job.component';

const routes: Routes = [
  { path: '', component: HomeJobComponent },
  { path: 'create-job', component: CreateJobComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
