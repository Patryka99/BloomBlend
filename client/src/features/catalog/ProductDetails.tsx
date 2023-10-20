import { Container, Divider, Grid, Table, TableBody, TableCell, TableContainer, TableRow, TextField, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Product } from "../../app/models/product";
import DetailSlider from "./DetailSlider";
import agent from "../../app/api/agent";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { LoadingButton } from "@mui/lab";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { addBasketItemAsync, removeBasketItemAsync } from "../basket/basketSlice";
import { getPrice } from "../../app/util/util";
import NotFound from "../../app/errors/NotFound";

export default function ProductDetails() {
    const { basket, status } = useAppSelector(state => state.basket);
    const dispatch = useAppDispatch();
    const { id } = useParams<{ id: string }>();
    const [product, setProduct] = useState<Product | null>(null);
    const [loading, setLoading] = useState(true);
    const [quantity, setQuantity] = useState(0);
    // const [pricePercent, setPricePercent] = useState(100);
    const [sizeMl] = useState<number | undefined>(100);
    var item = basket?.items.find(i => i.productId === product?.id)

    useEffect(() => {
        if (item) setQuantity(item.quantity);

        id && agent.Catalog.details(parseInt(id))
            .then(response => setProduct(response))
            .catch(error => console.log(error))
            .finally(() => setLoading(false))
    }, [id, item])

    // function handleRadioChange(event: any) {
    //     if (event.target.value >= 0) {
    //         setPricePercent(parseInt(event.target.value));
    //         setSizeMl(product?.inventoryItems.find(x => x.pricePercent === pricePercent)?.sizeMl);
    //     }
    //     console.log(sizeMl);
    //         console.log(pricePercent);
    // }

    function handleInputChange(event: any) {
        if (event.target.value >= 0 ) {
            setQuantity(parseInt(event.target.value));
        }
    }

    function handleUpdateCart() {
        if (!item || quantity > item.quantity) {
            const updatedQuantity = item ? quantity - item.quantity : quantity;
            dispatch(addBasketItemAsync({ productId: product?.id!, quantity: updatedQuantity, sizeMl: sizeMl }))
        } else {
            const updatedQuantity = item.quantity - quantity;
            dispatch(removeBasketItemAsync({ productId: product?.id!, quantity: updatedQuantity, sizeMl: item.sizeMl }))
        }
    }

    // var sortOptions: any[] = [
    // ]

    // product?.inventoryItems.map(item => (
    //     sortOptions.push({value: item.pricePercent, label: item.sizeMl})
    // ))

    if (loading) return <LoadingComponent message="Loading product..." />

    if (!product) return <NotFound />

    return (
        <Container maxWidth={false} sx={{ width: '80%', mb: 20 }}>
            <Grid container spacing={6} sx={{ mt: 3 }}>
                <Grid item xs={6}>
                    <DetailSlider pictureUrl={product.pictureUrl} pictureUrl2={product.pictureUrl2} pictureUrl3={product.pictureUrl3} />
                </Grid>
                <Grid item xs={5}>
                    <Typography variant='h3'>{product.name}</Typography>
                    <Divider sx={{ mb: 2 }} />
                    <Typography variant='h4' color='primary'>{getPrice(product.price)}</Typography>
                    <TableContainer>
                        <Table>
                            <TableBody>
                                <TableRow>
                                    <TableCell>Name</TableCell>
                                    <TableCell>{product.name}</TableCell>
                                </TableRow>
                                <TableRow>
                                    <TableCell>Description</TableCell>
                                    <TableCell>{product.description}</TableCell>
                                </TableRow>
                                <TableRow>
                                    <TableCell>Gender</TableCell>
                                    <TableCell>{product.sex}</TableCell>
                                </TableRow>
                                <TableRow>
                                    <TableCell>Brand</TableCell>
                                    <TableCell>{product.brand}</TableCell>
                                </TableRow>
                            </TableBody>
                        </Table>
                    </TableContainer>
                    {/* <Grid container sx={{ mt: 5 }}>
                        <RadioButtonGroup
                            selectedValue={pricePercent.toString()}
                            options={sortOptions}
                            onChange={(e) => handleRadioChange(e)}
                        />
                    </Grid> */}
                    <Grid container spacing={2} sx={{ mt: 3 }}>
                        <Grid item xs={6}>
                            <TextField
                                onChange={handleInputChange}
                                variant="outlined"
                                type='number'
                                label='Quantity in cart'
                                fullWidth
                                value={quantity}
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <LoadingButton
                                disabled={item?.quantity === quantity || (!item && quantity === 0)}
                                loading={status.includes('pending')}
                                onClick={handleUpdateCart}
                                sx={{ height: '55px' }}
                                color="primary"
                                size="large"
                                variant="contained"
                                fullWidth
                            >
                                {item ? 'Update Quantity' : 'Add to Cart'}
                            </LoadingButton>
                        </Grid>
                    </Grid>
                </Grid >
            </Grid >
        </Container >
    )
}