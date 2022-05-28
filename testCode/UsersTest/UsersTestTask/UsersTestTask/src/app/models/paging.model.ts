export class Paging {

  currentPage: number;
  pageSize: number;

  constructor(data: any) {
    this.currentPage = data.currentPage;
    this.pageSize = data.pageSize;
  }
}
