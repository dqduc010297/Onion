import { Component, OnInit, Input } from '@angular/core';
import { isNgTemplate } from '@angular/compiler';
import { Item } from './item';

@Component({
  selector: 'app-select',
  templateUrl: './select.component.html',
  styleUrls: ['./select.component.scss']
})
export class SelectComponent implements OnInit {

  constructor() { }
  // tslint:disable-next-line: no-input-rename
  @Input('data') data: Item[] = [];
  // tslint:disable-next-line: no-input-rename
  @Input('defaultValue') defaultValue: any;

  item: Item;

  ngOnInit() {
    console.log(this.data);
    if (this.defaultValue == null){
      this.item.value = 0;
      this.item.textDisplay = this.data[0].textDisplay;
    }
  }
  choosed(value) {
    console.log(value);
  }
}
