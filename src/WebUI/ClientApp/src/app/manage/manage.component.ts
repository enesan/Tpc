import { Component, OnInit } from '@angular/core';
import {CardClient, CardDto} from "../web-api-client";

@Component({
  selector: 'app-manage',
  templateUrl: './manage.component.html',
  styleUrls: ['./manage.component.css']
})
export class ManageComponent implements OnInit {

  readonly LINK = "https://localhost:44447/api/Card/3"
  constructor(private cardClient: CardClient) {

  }

  ngOnInit(): void {
  }

 getUnoCard() {
    return this.LINK;
 }

}
