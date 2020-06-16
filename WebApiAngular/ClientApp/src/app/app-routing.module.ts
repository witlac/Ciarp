import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConsultArticleComponent } from './components/AcademicProductivity/consult-article/consult-article.component';
import { Routes, RouterModule, Router } from '@angular/router';
import { ConsultRequestComponent } from './components/request/consult-request/consult-request.component';
import { CreateProductivityComponent } from './components/AcademicProductivity/create-productivity/create-productivity.component';


const routes: Routes = [
  {
    path: '',
    component: CreateProductivityComponent
  },
  {
    path: 'ConsultarProductividad',
    component: ConsultArticleComponent
  },
  {
    path: 'ConsultarSolicitud',
    component: ConsultRequestComponent
  },
  {
    path: 'RegistrarProductividad',
    component: CreateProductivityComponent
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
