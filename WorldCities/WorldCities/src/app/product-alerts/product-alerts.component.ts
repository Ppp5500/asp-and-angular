import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../product-list/products';

@Component({
  selector: 'app-product-alerts',
  templateUrl: './product-alerts.component.html',
  styleUrls: ['./product-alerts.component.css']
})
export class ProductAlertsComponent implements OnInit {

  @Input() product!: Product;
  constructor() { }

  ngOnInit(): void {
  }

}
