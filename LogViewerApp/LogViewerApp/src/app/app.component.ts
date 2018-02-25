import { Component, OnInit } from '@angular/core';
import { ElasticsearchService } from './elasticsearch.service';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/switchMap';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Component({
  selector: 'lv-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent implements OnInit {
  title = 'lv';
  radioModel: string = 'Middle';
  checkModel: any = { left: false, middle: true, right: false };
  someRange: number[] = [3, 5];
  searchTerm$ = new Subject<string>();
  subscription: Observable<string>;
  results: any;
  sources: any[];

  constructor(private esService: ElasticsearchService) {
    this.subscription = this.searchTerm$.debounceTime(1000).distinctUntilChanged().switchMap(term => this.doSomething(term));
  }
  ngOnInit(): void {

    this.subscription.subscribe(data => {
      this.results = data;
    });

    this.esService.getIndices().subscribe(data => {
      this.sources = data.map(d => { return { index: d.index, checked: false }; });
    });
  }
  onKeyUp(event) {
    this.searchTerm$.next(event.target.value);
  }

  doSomething(term: string) {
    return this.esService.fullTextSearch(this.sources.filter(s => s.checked).map(s => s.index), '', 'message', term);
  }

  sourceChecked(i) {
    let newElement: any = { index: this.sources[i].index, checked: !this.sources[i].checked };
    this.sources[i] = newElement;
  }
}
