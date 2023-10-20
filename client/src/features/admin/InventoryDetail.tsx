import { Container, Box, Typography, Button, Grid } from "@mui/material";
import BasketSummary from "../basket/BasketSummary";
import { Product } from "../../app/models/product";

interface Props {
    product: Product;
    setSelectedProduct: (id: number) => void

}

export default function OrderDetailed({ product, setSelectedProduct }: Props) {
    return (
        <Container maxWidth={false} sx={{ width: '80%' }}>
            <Box display='flex' justifyContent={"space-between"}>
                <Typography sx={{ p: 2 }} gutterBottom variant="h4">Product# {product.id}</Typography>
                <Button onClick={() => setSelectedProduct(0)} sx={{ m: 2 }} size="large" variant="contained">Back to Products</Button>
            </Box>
            {/* <BasketTable items={product as InventoryItem[]} isBasket={false} /> */}
            <Grid container sx={{mb: 15}}>
                <Grid item xs={6} />
                <Grid item xs={6}>
                    <BasketSummary subtotal={10} />
                </Grid>
            </Grid>
        </Container>
    )
}