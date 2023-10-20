import * as yup from 'yup';

export const validationSchema = yup.object({
    name: yup.string().required('Name is required'),
    brand: yup.string().required('Brand is required'),
    sex: yup.string().required('Genre is Required'),
    price: yup.number().required().moreThan(100),
    description: yup.string().required(),
    pictureUrl: yup.mixed().when('productUrl', {
        is: (value: string) => !value,
        then: (schema) => schema.required('Please provide an image')
    }),
    pictureUrl2: yup.mixed().when('productUrl', {
        is: (value: string) => !value,
        then: (schema) => schema.required('Please provide an image')
    }),
    pictureUrl3: yup.mixed().when('productUrl', {
        is: (value: string) => !value,
        then: (schema) => schema.required('Please provide an image')
    }),
})
