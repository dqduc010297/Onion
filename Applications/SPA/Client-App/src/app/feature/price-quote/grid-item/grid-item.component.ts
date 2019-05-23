import { Component, OnInit, Input } from '@angular/core';
import { Drawing } from 'src/app/model/Drawing';
declare var $: any;
@Component({
  selector: 'app-grid-item',
  templateUrl: './grid-item.component.html',
  styleUrls: ['./grid-item.component.scss']
})
export class GridItemComponent implements OnInit {

// tslint:disable-next-line: no-input-rename
  @Input('item') item: Drawing;
  
  constructor() { }

  ngOnInit() {
    // console.log(123);
    $('#itemScan').modal('show');
    if ($('#itemScan').data('bs.modal').isShown === true) {
      console.log('Modal is open');
    }
  }

// tslint:disable-next-line: use-life-cycle-interface
  ngOnDestroy() {
    $('#itemScan').modal('hide');
  }
}
