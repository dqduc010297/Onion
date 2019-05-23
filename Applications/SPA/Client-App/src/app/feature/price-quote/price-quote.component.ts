import { Component, OnInit } from '@angular/core';
import { PriceQuoteService } from './service/price-quote.service';
import { Drawing } from 'src/app/model/Drawing';

@Component({
  selector: 'app-price-quote',
  templateUrl: './price-quote.component.html',
  styleUrls: ['./price-quote.component.scss']
})
export class PriceQuoteComponent implements OnInit {

  items: Drawing[] = [
    {
      code: 'M443-1',
      codeManager: 'NKY19003640',
      quatity: 120,
      price: 0,
      material: 'SS400',
      deliveryDate: new Date('05/13/2019'),
      note: '',
      supplierName: 'KTVN',
      cost: 548
    },
    {
      code: 'M443-2',
      codeManager: 'NKY19003641',
      quatity: 120,
      price: 0,
      material: 'SS400',
      deliveryDate: new Date('05/13/2019'),
      note: '',
      supplierName: 'ICHI',
      cost: 662
    }
  ];

  constructor(
    private _priceQuoteService: PriceQuoteService
  ) { }

  ngOnInit() {

  }

  selectedItem(item) {
    console.log(item);
  }
}
