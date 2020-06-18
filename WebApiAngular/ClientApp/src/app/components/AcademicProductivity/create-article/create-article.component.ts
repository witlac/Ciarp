import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup, NgModel } from '@angular/forms';
import { Article } from '../../../models/article';
import { ArticleService } from '../../../services/article.service';
import { FormsModule } from '@angular/forms';



@Component({
  selector: 'app-create-article',
  templateUrl: './create-article.component.html',
  styleUrls: ['./create-article.component.css']
})
export class CreateArticleComponent implements OnInit {

  formGroup: FormGroup;
  forms: FormsModule;
  article: Article;
  constructor(
    private articleService: ArticleService,
    private formBuilder: FormBuilder,
  ) { }

  ngOnInit() {
    this.buildForm();
  }

  private buildForm() {
    this.article = new Article();
    this.formGroup = this.formBuilder.group({
      title: [this.article.title, Validators.required],
      tipoArticulo: [this.article.articleType, Validators.required],
      tipoRevista: [this.article.journalType, Validators.required],
      issn: [this.article.issn, Validators.required],
      idioma: [this.article.language, Validators.required],
      presentaCredito: [this.article.credit, Validators.required],
      numeroAutores: [this.article.numberOfAuthors, Validators.required],

    })
  }

  onSubmit() {
    console.log("envia");
    if (this.formGroup.invalid) {
      console.log("alv");

      return;
    }
    console.log("exito");

    this.addArticle();
  }

  addArticle() {
    this.article = this.formGroup.value;
    this.article.documentTeacher = "123";
    console.log(this.article);
    this.articleService.post(this.article).subscribe(p => {
      if (p != null) {
        alert('Articulo creado con exito!')
        this.article = p;
      }
    });
  }

  

  get control() { return this.formGroup.controls; }


}
