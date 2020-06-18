import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgClass} from '@angular/common';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { ConsultArticleComponent } from './components/AcademicProductivity/consult-article/consult-article.component';
import { AppRoutingModule } from './app-routing.module';
import { ConsultRequestComponent } from './components/request/consult-request/consult-request.component';
import { CreateBookComponent } from './components/AcademicProductivity/create-book/create-book.component';
import { CreateSoftwareComponent } from './components/AcademicProductivity/create-software/create-software.component';
import { CreateEventComponent } from './components/AcademicProductivity/create-event/create-event.component';
import { CreateProductivityComponent } from './components/AcademicProductivity/create-productivity/create-productivity.component';
import { CreateArticleComponent } from './components/AcademicProductivity/create-article/create-article.component';
import { ArticleService } from './services/article.service';

@NgModule({
  declarations: [
    AppComponent,
    ConsultArticleComponent,
    ConsultRequestComponent,
    CreateBookComponent,
    CreateSoftwareComponent,
    CreateEventComponent,
    CreateProductivityComponent,
    CreateArticleComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: AppComponent, pathMatch: 'full' },
    ]),
    AppRoutingModule
  ],
  providers: [ArticleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
