import { Card, CardActionArea, CardContent, CardMedia, Grid, Typography } from "@mui/material";
import { Product } from "../../app/models/product";
import { AddShoppingCart } from "@mui/icons-material";
import { Link } from "react-router-dom";
import { LoadingButton } from "@mui/lab";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { addBasketItemAsync } from "../basket/basketSlice";

interface Props {
    product: Product;
}

export default function ProductCard({ product }: Props) {
    const {status} = useAppSelector(state => state.basket);
    const dispatch = useAppDispatch();

    return (
        <Card sx={{ maxWidth: 300 }}>
            <CardActionArea component={Link} to={`/catalog/${product.id}`}>
                <CardMedia
                    component="img"
                    alt={product.name}
                    height="330"
                    sx={{ objectFit: "fill" }}
                    image={product.pictureUrl}

                />
            </CardActionArea>
            <CardContent sx={{ paddingLeft: 4 }}>
                <Typography gutterBottom variant="h6" component="div" sx={{ fontWeight: 'bold' }}>
                    {product.name}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                    Gene: {product.sex} &nbsp;&nbsp;•&nbsp;&nbsp; Brand: {product.brand}
                </Typography>
                <br></br>
                <Grid container alignItems="center">
                    <Grid item xs={8}>
                        <Typography variant="h5" color="primary">
                            ${(product.price / 100).toFixed(2)}
                        </Typography>
                    </Grid>
                    <Grid item xs={4}>
                        <LoadingButton
                            endIcon={<AddShoppingCart fontSize='large' color="primary" />}
                            loading={status.includes('pendingAddItem' + product.id)}
                            loadingPosition='end'
                            onClick={() => dispatch(addBasketItemAsync({productId: product.id}))}
                            size='large'>
                            
                        </LoadingButton>
                    </Grid>
                </Grid>
            </CardContent>
        </Card>
    )
}