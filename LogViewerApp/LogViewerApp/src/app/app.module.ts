import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';


import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { NouisliderModule } from 'ng2-nouislider';

import { AppComponent } from './app.component';
import { ElasticsearchService } from './elasticsearch.service';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    NouisliderModule,
    ButtonsModule.forRoot(),
    BsDropdownModule.forRoot()
  ],
  providers: [ElasticsearchService],
  bootstrap: [AppComponent]
})
export class AppModule { }
