import { Component, OnInit } from '@angular/core';
import {CardClient, CardDto, FileParameter} from "../web-api-client";

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

  uploadFile() {
    let fileFromInput = (document.getElementById("file") as HTMLInputElement).files[0];
    if (fileFromInput === null) return;

    let fileParameter: FileParameter = {data: fileFromInput, fileName: fileFromInput.name};

    this.cardClient.upload(fileParameter).subscribe();
  }

 getUnoCard() {
    return this.LINK;
 }

}
