import { BrowserModule, DomSanitizer } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';


import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { NouisliderModule } from 'ng2-nouislider';

import { AppComponent } from './app.component';
import { ElasticsearchService } from './elasticsearch.service';
import { LOCALE_ID } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import localeFr from '@angular/common/locales/de';
import { Safe } from './safeHtml.pipe';

// the second parameter 'fr' is optional
registerLocaleData(localeFr, 'de');


@NgModule({
  declarations: [
    AppComponent,
    Safe
  ],
  imports: [
    BrowserModule,
    FormsModule,
    NouisliderModule,
    ButtonsModule.forRoot(),
    BsDropdownModule.forRoot()
  ],
  providers: [{ provide: LOCALE_ID, useValue: 'de' }, ElasticsearchService, Safe],
  bootstrap: [AppComponent]
})
export class AppModule { }
