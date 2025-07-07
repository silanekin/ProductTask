import { Component } from '@angular/core';
import { ProductListComponent } from './components/product-list/product-list.component';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'productTask';
}
