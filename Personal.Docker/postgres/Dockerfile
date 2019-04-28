FROM postgres:9.6.12 as postgres
LABEL personal="true"

# Create config dir (if not created now we get permissions issues
# at runtime in the entrypoint) and install `envsubst`
RUN touch /tmp/noop \
    && mkdir -p /etc/postgresql \
    && apt-get update \
    && apt-get install -y --no-install-recommends gettext-base \
    && apt-get clean

# Add the default postgresql config template
COPY ./postgresql.tpl.conf /etc/postgresql/postgresql.tpl.conf

# Setup the default entrypoint and cmd
COPY ./entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh
ENTRYPOINT [ "/entrypoint.sh" ]
CMD [ "postgres", "-c", "config_file=/etc/postgresql/postgresql.conf" ]