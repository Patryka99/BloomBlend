import {
    Card,
    CardActions,
    CardContent,
    Grid,
    Skeleton
} from "@mui/material";

export default function ProductCardSkeleton() {
    return (
        <Grid item xs component={Card} sx={{width: 300}} >
            <Skeleton sx={{ height: 320 }} animation="wave" variant="rectangular" />
            <CardContent>
                <>
                    <Skeleton animation="wave" height={40} style={{ marginBottom: 6 }} />
                    <Skeleton animation="wave" height={40} width="80%" />
                </>
            </CardContent>
            <CardActions>
                <>
                    <Skeleton animation="wave" height={40} width='40%' />
                    <Skeleton animation="wave" height={40} width="20%" />
                </>
            </CardActions>
        </Grid>
    )
}