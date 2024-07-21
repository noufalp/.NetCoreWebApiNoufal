import { Component, OnInit  } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../_services/product.service';
import { Product } from '../Model/Product';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.scss']
})

export class ProductEditComponent implements OnInit{
  product: Product | undefined;

  constructor(private route: ActivatedRoute, private productService: ProductService, private router: Router) { }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id')!;
    this.productService.getProduct(id).subscribe((product) => {
      this.product = product;
    });
  }

  updateProduct() {
    const id = +this.route.snapshot.paramMap.get('id')!;
    this.productService.updateProduct(id, this.product).subscribe(() => {
      this.router.navigate(['/products']);
    });
  }
}
