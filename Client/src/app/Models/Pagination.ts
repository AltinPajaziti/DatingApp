export interface Pagination{
    CurrentPAge : number;
    itemsPerPage :number ;
    totalItems : number;
    totalPages : number;
}

export class Paginatedresult<T> {
    items ? : T ;
    pagination ?: Pagination 

}