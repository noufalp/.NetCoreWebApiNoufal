import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from '../_services/product.service';


@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss']
})
export class AddProductComponent {
  product: any = {};

  constructor(private productService: ProductService, private router: Router) { }

  addProduct() {
    this.productService.addProduct(this.product).subscribe(() => {
      this.router.navigate(['/products']);
    });
  }
}
