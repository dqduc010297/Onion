import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-price-quote',
  templateUrl: './price-quote.component.html',
  styleUrls: ['./price-quote.component.scss', '../../share/style/style.scss']
})
export class PriceQuoteComponent implements OnInit {

  selectedData: any[] = [
    {textDisplay: 'Cream', value: 0},
    {textDisplay: 'Cheese', value: 1},
    {textDisplay: 'Milk', value: 2},
    {textDisplay: 'Honey', value: 3}
  ];
  textDisplay = 'Cream';
  value = 0;
  constructor() { }

  ngOnInit() {
    console.log(this.selectedData);
  }

}
