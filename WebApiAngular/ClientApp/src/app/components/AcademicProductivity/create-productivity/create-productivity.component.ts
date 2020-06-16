import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-create-productivity',
  templateUrl: './create-productivity.component.html',
  styleUrls: ['./create-productivity.component.css']
})
export class CreateProductivityComponent implements OnInit {

  bookComponent: boolean = false;
  articleComponent: boolean = true;
  eventComponent: boolean = false;
  softwareComponent: boolean = false;

  constructor() { }

  ngOnInit() {
  }

  ChangeToBook() {
    this.articleComponent = false;
    this.bookComponent = true;
    this.eventComponent = false;
    this.softwareComponent = false;
  }

  ChangeToArticle() {
    this.articleComponent = true;
    this.bookComponent = false;
    this.eventComponent = false;
    this.softwareComponent = false;
  }

  ChangeToSoftware() {
    this.articleComponent = false;
    this.bookComponent = false;
    this.eventComponent = false;
    this.softwareComponent = true;
  }

  ChangeToEvent() {
    this.articleComponent =false;
    this.bookComponent = false;
    this.eventComponent = true;
    this.softwareComponent = false;
  }

}
