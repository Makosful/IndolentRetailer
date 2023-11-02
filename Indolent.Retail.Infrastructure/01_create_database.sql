CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE IF NOT EXISTS "customers"
(
    "uuid"       VARCHAR DEFAULT uuid_generate_v4
        (
        ) PRIMARY KEY,
    "first_name" VARCHAR NOT NULL,
    "last_name"  VARCHAR NOT NULL,
    "phone"      VARCHAR NOT NULL,
    "email"      VARCHAR NOT NULL,
    "address"    VARCHAR NOT NULL
);

CREATE TABLE IF NOT EXISTS "products"
(
    "id"
        SERIAL
        PRIMARY
            KEY,
    "name"
        VARCHAR
        NOT
            NULL
);

CREATE TABLE IF NOT EXISTS "orders"
(
    "id"
        SERIAL
        PRIMARY
            KEY,
    "customer_id"
        VARCHAR
        NOT
            NULL,
    CONSTRAINT
        "fk_customer"
        FOREIGN
            KEY
            (
             "customer_id"
                ) REFERENCES "customers"
            (
             "uuid"
                )
);

CREATE TABLE IF NOT EXISTS "order_products"
(
    "order_id"
        INTEGER
        NOT
            NULL,
    "product_id"
        INTEGER
        NOT
            NULL,
    "amount"
        INTEGER
        NOT
            NULL,
    CONSTRAINT
        "fk_product"
        FOREIGN
            KEY
            (
             "product_id"
                ) REFERENCES "products"
            (
             "id"
                ),
    CONSTRAINT "fk_order" FOREIGN KEY
        (
         "order_id"
            ) REFERENCES "orders"
            (
             "id"
                ),
    CONSTRAINT "pk_id" PRIMARY KEY
        (
         "order_id",
         "product_id"
            )
);
