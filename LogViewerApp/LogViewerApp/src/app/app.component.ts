import { Component, OnInit } from '@angular/core';
import { Client } from 'elasticsearch';

@Component({
  selector: 'lv-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent implements OnInit {
  title = 'lv';
  radioModel: string = 'Middle';
  checkModel: any = { left: false, middle: true, right: false };
  someRange: number[] = [3,5];
  private client: Client = null;
  constructor() {
    this.client = new Client({ host: 'localhost:9200', log: 'trace' });
  }
  ngOnInit(): void {
    this.client.ping({
      requestTimeout: Infinity,
      body: 'hello Javascript!'
    });
  }

}
