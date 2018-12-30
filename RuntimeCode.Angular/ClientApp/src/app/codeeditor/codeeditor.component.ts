import { Component, Inject, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

//import 'brace/theme/github';
//import 'brace/mode/sql';
declare let ace: any;

@Component({
  selector: 'app-codeeditor',
  templateUrl: './codeeditor.component.html',
  styleUrls: ['./codeeditor.component.css']
})

export class CodeeditorComponent implements OnInit, AfterViewInit {

  @ViewChild('highlight') highlight;
  @ViewChild('editorInfinity') editorInfinity;
  @ViewChild('firstEditor') firstEditor;

  public _http: HttpClient;
  public _baseurl = '';
  public text = '';
  public options: any = {maxLines: Infinity, printMargin: false};

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string){

  }

  ngAfterViewInit() {

    this.firstEditor.getEditor().setTheme('eclipse');
    this.firstEditor.getEditor().setMode('csharp');

  }

  ngOnInit(): void {
    console.log('Init');
  }

  onChange(code) {
      console.log('new code', code);
  }

  compileCode(item: any): Observable<any> {
      return this.http.post<any>(this.baseUrl, item);
  }

}
