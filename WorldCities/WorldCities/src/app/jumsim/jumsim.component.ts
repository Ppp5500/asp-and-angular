import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-jumsim',
  templateUrl: './jumsim.component.html',
  styleUrls: ['./jumsim.component.css']
})
export class JumsimComponent implements OnInit {
  selected!: Date | null;
  num_dorirock: number = 6;
  num_salad: number = 3;
  num_etc: number = 1;

  longText = `The Shiba Inu is the smallest of the six original and distinct spitz breeds of dog
  from Japan. A small, agile dog that copes very well with mountainous terrain, the Shiba Inu was
  originally bred for hunting.`;

  constructor() { }

  ngOnInit(): void {
  }

}
