import LoadingComponent from "../../app/layout/LoadingComponent";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import ProductList from "./ProductList";
import { setPageNumber, setProductParams } from "./catalogSlice";
import { Container, Divider, Grid, Paper, Typography } from "@mui/material";
import ProductSearch from "./ProductSearch";
import RadioButtonGroup from "../../app/components/RadioButtonGroup";
import CheckboxButtons from "../../app/components/CheckboxButtons";
import AppPagination from "../../app/components/AppPagination";
import CatalogSlider from "./CatalogSlider";
import useProducts from "../../app/hooks/useProducts";

const sortOptions = [
    { value: 'name', label: 'Alphabetical' },
    { value: 'priceDesc', label: 'Price - Hight to low' },
    { value: 'price', label: 'Price - Low to hight' },
]

export default function Catalog() {
    const {products, brands, sexs, filtersLoaded, metaData} = useProducts();
    const { productParams } = useAppSelector(state => state.catalog);
    const dispatch = useAppDispatch();

    if (!filtersLoaded) return <LoadingComponent message="Loading products..." />

    return (
        <Container maxWidth={false} sx={{ width: '80%' }}>
            <CatalogSlider />
            <Grid container columnSpacing={4}>
                <Grid item xs={3}>
                    <Paper sx={{ mb: 2 }}>
                        <ProductSearch />
                    </Paper>
                    <Paper sx={{ mb: 2, p: 2 }}>
                        <Typography variant="h5"> Sort By</Typography>
                        <Divider sx={{ mb: 1, mt: 1, backgroundColor: 'primary.dark', }} />
                        <RadioButtonGroup
                            selectedValue={productParams.orderBy}
                            options={sortOptions}
                            onChange={(e) => dispatch(setProductParams({ orderBy: e.target.value }))}
                        />
                    </Paper>
                    <Paper sx={{ mb: 2, p: 2 }}>
                        <Typography variant="h5"> Brand</Typography>
                        <Divider sx={{ mb: 1, mt: 1, backgroundColor: 'primary.dark', }} />
                        <CheckboxButtons
                            items={brands}
                            checked={productParams.brands}
                            onChange={(items: string[]) => dispatch(setProductParams({ brands: items }))}
                        />
                    </Paper>
                    <Paper sx={{ mb: 2, p: 2 }}>
                        <Typography variant="h5"> Gender</Typography>
                        <Divider sx={{ mb: 1, mt: 1, backgroundColor: 'primary.dark', }} />
                        <CheckboxButtons
                            items={sexs}
                            checked={productParams.sexs}
                            onChange={(items: string[]) => dispatch(setProductParams({ sexs: items }))}
                        />
                    </Paper>
                </Grid>
                <Grid item xs={9}>
                    <ProductList products={products} />
                </Grid>
                <Grid item xs={3} />
                <Grid item xs={9} sx={{ mb: 2, mt: 3 }}>
                    {metaData &&
                        <AppPagination
                            metaData={metaData}
                            onPageChange={(page: number) => dispatch(setPageNumber({ pageNumber: page }))}
                        />}
                </Grid>
            </Grid>
        </Container>
    )
}