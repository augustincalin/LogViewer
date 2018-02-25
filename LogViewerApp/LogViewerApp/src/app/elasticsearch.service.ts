import { Injectable } from '@angular/core';
import { Client } from 'elasticsearch';
import { Observable } from 'rxjs/Observable';
import { fromPromise } from 'rxjs/observable/fromPromise';
import { CatIndicesParams } from 'elasticsearch';

@Injectable()
export class ElasticsearchService {
  private client: Client = null;

  constructor() {
    this.client = new Client({ host: 'localhost:9200', log: 'trace' });
  }

  ping(message: string): Observable<any> {
    return fromPromise(this.client.ping({
      requestTimeout: Infinity,
      body: message
    }));
  }

  fullTextSearch(index, type, field, queryText): any {
    return this.client.search({
      index: index,
      type: type,
      //storedFields: ['_index'],
      body: {
        'query': {
          'match_phrase_prefix': {
            [field]: queryText,
          }
        }
      },
      // response for each document with only 'fullname' and 'address' fields
      // '_source': ['fullname', 'address']
    });
  }

  getIndices(): any {
    return fromPromise(this.client.cat.indices({ format: 'json' }));
  }

}
