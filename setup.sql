CREATE TABLE bids(  
    id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'update time',
    bidPrice decimal NOT NULL COMMENT 'Offer bid price',
    contractorId int not NULL comment 'FK: contractors',
    jobId int not NULL comment 'FK: jobs',
    FOREIGN KEY(contractorId) REFERENCES contractors(id) ON DELETE CASCADE,
    FOREIGN KEY(jobId) REFERENCES jobs(id) ON DELETE CASCADE
) default charset utf8 comment '';
drop table bids;
